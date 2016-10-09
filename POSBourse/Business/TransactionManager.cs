﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using POSBourse.Bean;

namespace POSBourse.Business
{
    public class TransactionManager
    {
        public decimal getRemisesSumFromCollection(ObservableCollection<TableRemise> RemiseCollection)
        {
            decimal valeur = 0;

            foreach (var remise in RemiseCollection)
            {
                decimal valeurDecimal = decimal.Parse(remise.Montant);
                valeur += valeurDecimal;
            }

            return valeur;
        }

        public decimal getAvoirSumFromCollection(ObservableCollection<TableAvoir> AvoirCollection)
        {
            decimal valeur = 0;

            foreach (var avoir in AvoirCollection)
            {
                decimal valeurDecimal = decimal.Parse(avoir.Montant);
                valeur += valeurDecimal;
            }

            return valeur;
        }

        public decimal getEchangeDirectSumFromCollection(ObservableCollection<TableEchangeDirect> EchangeDirectCollection)
        {
            decimal valeur = 0;

            foreach (var echange in EchangeDirectCollection)
            {
                decimal valeurDecimal = decimal.Parse(echange.Valeur);
                valeur += valeurDecimal;
            }

            return valeur;
        }

        public decimal getProductsSumFromCollection(ObservableCollection<TableProduct> ProductsCollection)
        {
            decimal valeur = 0;

            foreach (var product in ProductsCollection)
            {
                decimal valeurDecimal = decimal.Parse(product.Prix);
                valeur += valeurDecimal;
            }

            return valeur;
        }

        public ObservableCollection<TableRemise> calculateMontantRemiseFromTableRemise(ObservableCollection<TableRemise> RemiseCollection,
            ObservableCollection<TableProduct> ProductsCollection,
            ObservableCollection<TableAvoir> AvoirCollection,
            ObservableCollection<TableEchangeDirect> EchangeDirectCollection)
        {
            CalculResultBean resultBean = getResultBeanWithoutRemises(AvoirCollection, EchangeDirectCollection, ProductsCollection);

            decimal totalAfterAvoirAndEchangeDirect = resultBean.totalProduits - (resultBean.totalAvoir + resultBean.totalEchangeDirect);
            
            foreach (var remise in RemiseCollection)
            {
                if(remise.Type == "POURCENTAGE")
                {
                    decimal valeurRemiseDecimal = decimal.Parse(remise.Valeur);

                    decimal calculatedRemiseValue = valeurRemiseDecimal * totalAfterAvoirAndEchangeDirect / 100;

                    totalAfterAvoirAndEchangeDirect -= calculatedRemiseValue;

                    remise.Montant = string.Format("{0:0.00}", totalAfterAvoirAndEchangeDirect);
                }
                else if(remise.Type == "VALEUR")
                {
                    remise.Montant = remise.Valeur;
                }
            }

            return RemiseCollection;
        }

        public CalculResultBean getResultBeanWithoutRemises(ObservableCollection<TableAvoir> AvoirCollection,
            ObservableCollection<TableEchangeDirect> EchangeDirectCollection,
            ObservableCollection<TableProduct> ProductsCollection)
        {
            decimal avoirsSum = getAvoirSumFromCollection(AvoirCollection);
            decimal echangeDirectSum = getEchangeDirectSumFromCollection(EchangeDirectCollection);
            decimal productsSum = getProductsSumFromCollection(ProductsCollection);
            
            CalculResultBean result = new CalculResultBean
            {
                totalProduits = productsSum,
                totalAvoir = avoirsSum,
                totalEchangeDirect = echangeDirectSum
            };
            
            return result;
        }

        public CalculResultBean getFinalCalculResultBean(ObservableCollection<TableRemise> RemiseCollection,
            ObservableCollection<TableAvoir> AvoirCollection,
            ObservableCollection<TableEchangeDirect> EchangeDirectCollection,
            ObservableCollection<TableProduct> ProductsCollection,
            
            decimal monnaiePayeeESP,
            decimal monnaiePayeeCB,
            decimal monnaiePayeeCHEQUE,
            
            decimal aRendreAVOIR,
            decimal aRendreESP)
        {

            CalculResultBean calculResultBean = getResultBeanWithoutRemises(AvoirCollection, EchangeDirectCollection, ProductsCollection);

            //Si une valeur est entrée manuellement dans la case rendreAvoir...
            if (aRendreAVOIR > 0)
            {
                calculResultBean.ARendreAvoir = aRendreAVOIR;
            }
            else if (aRendreESP > 0)
            {
                calculResultBean.ARendreESP = aRendreESP;
            }

            //Calcul de la monnaie payée
            calculResultBean.monnaiePayeeESP = monnaiePayeeESP;
            calculResultBean.monnaiePayeeCB = monnaiePayeeCB;
            calculResultBean.monnaiePayeeCHEQUE = monnaiePayeeCHEQUE;

            calculResultBean.monnaiePayee = monnaiePayeeESP + monnaiePayeeCB + monnaiePayeeCHEQUE;

            //Calcul de la remise...
            ObservableCollection<TableRemise> CalculatedRemiseCollection = calculateMontantRemiseFromTableRemise(RemiseCollection, ProductsCollection, AvoirCollection, EchangeDirectCollection);
            calculResultBean.totalRemise = getRemisesSumFromCollection(CalculatedRemiseCollection);

            //Calcul total à payer...
            calculResultBean.totalAPayer = calculResultBean.totalProduits;

            //Calcul des réductions
            decimal reductions = (calculResultBean.totalAvoir + calculResultBean.totalRemise + calculResultBean.totalEchangeDirect);

            //Calcul reste à payer...
            calculResultBean.resteAPayer = calculResultBean.totalProduits - reductions;
            calculResultBean.resteAPayer = Math.Abs(calculResultBean.resteAPayer);

            //Calcul monnaie à rendre...
            calculResultBean.ARendre = calculResultBean.monnaiePayee - calculResultBean.resteAPayer;

            if(calculResultBean.ARendre <= 0)
            {
                calculResultBean.ARendre = 0;
            }
            else
            {
                calculResultBean.ARendre = Math.Abs(calculResultBean.ARendre);
            }

            //Calcul des réductions...
            calculResultBean.totalReductions = calculResultBean.totalEchangeDirect + calculResultBean.totalAvoir + calculResultBean.totalRemise;

            //Si on a saisi le montant ARendreAvoir à la main...
            if (calculResultBean.totalReductions - calculResultBean.totalProduits > 0 && calculResultBean.ARendreAvoir > 0)
            {
                calculResultBean.ARendreESP = Math.Round(((calculResultBean.totalReductions - (calculResultBean.totalProduits + calculResultBean.ARendreAvoir)) * Convert.ToDecimal(0.7142857)), 2, MidpointRounding.ToEven);
            }
            //Si on a saisi le montant ARendreESP à la main...
            else if (calculResultBean.totalReductions - calculResultBean.totalProduits > 0 && calculResultBean.ARendreESP > 0)
            {
                calculResultBean.ARendreAvoir = (calculResultBean.totalReductions-calculResultBean.totalProduits) - (calculResultBean.ARendreESP + (calculResultBean.ARendreESP*40)/100);
            }
            else if(calculResultBean.totalReductions - calculResultBean.totalProduits > 0)
            {
                calculResultBean.ARendreAvoir = calculResultBean.totalReductions - calculResultBean.totalProduits;
                calculResultBean.ARendreESP = Math.Round(calculResultBean.ARendreAvoir*Convert.ToDecimal(0.7142857), 2, MidpointRounding.ToEven);
            }

            //Controle des valeurs qui ne peuvent pas être négatives...
            if (calculResultBean.ARendreAvoir < 0)
            {
                calculResultBean.ARendreAvoir = 0;
            }
            if (calculResultBean.ARendreESP < 0)
            {
                calculResultBean.ARendreESP = 0;
            }

            return calculResultBean;
        }
    }
}
