﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApplication5.Models;

namespace WebApplication5.Security
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            veritabani3Entities model = new veritabani3Entities();
            Kullanici user = model.Kullanici.FirstOrDefault(x => x.KullaniciAdi == username);
            string rol = user.Rol;
            char[] chars = rol.ToCharArray();
            string[] roller = new string[chars.Length];
           
            for(int i=0; i<roller.Length; i++)
            {
                roller[i] = chars[i].ToString();
            }

            return roller;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}