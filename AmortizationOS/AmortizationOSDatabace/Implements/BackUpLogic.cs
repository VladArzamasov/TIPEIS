﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AmortizationOSBusinessLogic.BusinessLogics;

namespace AmortizationOSDatabase.Implements
{
    public class BackUpLogic : BackUpAbstractLogic
    {
        protected override Assembly GetAssembly()
        {
            return typeof(BackUpLogic).Assembly;
        }

        protected override List<PropertyInfo> GetFullList()
        {
            using (var context = new AmortizationOSDatabase())
            {
                Type type = context.GetType();
                return type.GetProperties().Where(x => x.PropertyType.FullName.StartsWith("Microsoft.EntityFrameworkCore.DbSet")).ToList();
            }
        }

        protected override List<T> GetList<T>()
        {
            using (var context = new AmortizationOSDatabase())
            {
                return context.Set<T>().ToList();
            }
        }
    }
}
