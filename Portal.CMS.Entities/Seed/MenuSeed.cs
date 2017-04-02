﻿using Portal.CMS.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Portal.CMS.Entities.Seed
{
    public static class MenuSeed
    {
        public static void Seed(PortalEntityModel context)
        {
            if (!context.Menus.Any(x => x.MenuName == "Main Menu"))
            {
                var menuItems = new List<MenuItem>();

                var authenticatedRole = context.Roles.First(x => x.RoleName == "Authenticated");

                menuItems.Add(new MenuItem { LinkText = "Home", LinkURL = "/Home/Index", LinkIcon = "fa-home" });
                menuItems.Add(new MenuItem { LinkText = "Blog", LinkURL = "/Blog/Read/Index", LinkIcon = "fa-book" });

                context.Menus.Add(new MenuSystem { MenuName = "Main Menu", MenuItems = menuItems });

                context.SaveChanges();

                context.Menus.First(x => x.MenuName == "Main Menu").MenuItems.Add(new MenuItem
                {
                    LinkText = "My Profile",
                    LinkURL = "/MyProfile/Index",
                    LinkIcon = "fa-user",
                    MenuItemRoles = new List<MenuItemRole>
                    {
                        new MenuItemRole { RoleId = authenticatedRole.RoleId}
                    }
                });
            }
        }
    }
}