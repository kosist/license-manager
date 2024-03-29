﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace LicenseManagerWeb.ViewModels
{
    public class BaseViewModel<TEntity>
    where TEntity: BaseItem
    {
        public TEntity Entity { get; set; }
    }
}
