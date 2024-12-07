using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEUProject_CSharp_OutbackPOS.Model;
using DEUProject_CSharp_OutbackPOS.Data;
namespace DEUProject_CSharp_OutbackPOS.Controller
{
    public class MenuController
    {
        private MenuRepository menuRepository = new MenuRepository();

        public List<OutbackMenu> GetAllMenus()
        {
            return menuRepository.GetAllMenus();
        }

        public OutbackMenu GetMenuById(int menuID)
        {
            return menuRepository.GetMenuById(menuID);
        }

        public void AddMenu(OutbackMenu menu)
        {
            menuRepository.AddMenu(menu);
        }

        public void UpdateMenu(OutbackMenu menu)
        {
            menuRepository.UpdateMenu(menu);
        }

        public void DeleteMenu(int menuID)
        {
            menuRepository.DeleteMenu(menuID);
        }
    }
}
