﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccess;

namespace Business
{
    public class BrandBusiness
    {
        public List<Brand> Brands()
        {
            List<Brand> brands = new List<Brand>();
            AccessData date = new AccessData();
            try
            {
                date.setQuery("Select Id, Descripcion From MARCAS");
                date.executeReader();
                
                while (date.Reader.Read())
                {
                    Brand aux = new Brand();
                    aux.Id = (int)date.Reader["Id"];
                    aux.Description = (string)date.Reader["Descripcion"];
                    brands.Add(aux);
                }
                return brands;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                date.closeConnection();
            }
        }
    }
}
