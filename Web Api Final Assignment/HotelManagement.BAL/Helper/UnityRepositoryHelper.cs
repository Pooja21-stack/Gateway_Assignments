using System;
using System.Collections.Generic;
using System.Text;
using HotelManagement.DAL.Repository;
using Unity.Extension;
using Unity;

namespace HotelManagement.BAL.Helper
{
   public  class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IHotelRepository, HotelRepository>();
        }
    }
}
