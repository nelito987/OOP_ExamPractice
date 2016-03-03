﻿using RestaurantManager.Models;

namespace RestaurantManager.Engine.Factories
{
    using System;
    using RestaurantManager.Interfaces;
    using RestaurantManager.Interfaces.Engine;

    public class RecipeFactory : IRecipeFactory
    {
        public IDrink CreateDrink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
        {
           return new Drink(name, price, calories, quantityPerServing, MetricUnit.Milliliters, timeToPrepare, isCarbonated);
        }

        public ISalad CreateSalad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
        {
            return new Salad(name, price, calories, quantityPerServing, timeToPrepare, containsPasta);
        }
        
        public IMainCourse CreateMainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string type)
        {
            MainCourseType typeEnum = (MainCourseType) Enum.Parse(typeof (MainCourseType), type);
            return new MainCourse(name, price, calories, quantityPerServing, timeToPrepare, isVegan, typeEnum);
        }

        public IDessert CreateDessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
        {
           return new Dessert(name, price, calories, quantityPerServing, timeToPrepare, isVegan);
        }
    }
}