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
        MenuRepository menuRepository = new MenuRepository();
        public List<OutbackMenu> GetAllMenus()
        {
            return menuRepository.GetAllMenus();
        }
    }
}
