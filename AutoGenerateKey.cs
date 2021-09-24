using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BTViDuMVCGiaiPTBac1.Models
{
    public class AutoGenerateKey
    {

        public string GenerateKey(string id)
        {

            string strkey = "";
            string numPart = "", strPart = "", strPhanso = "";

            numPart = Regex.Match(id, @"\d+").Value;
            strPart = Regex.Match(id, @"\D+").Value;

            int Phanso = Convert.ToInt32(numPart) + 1;

            for(int i = 0; i < numPart.Length - Phanso.ToString().Length; i++)
            {
                strPhanso += "0";
            }
            strPhanso += Phanso;
            strkey = strPart + strPhanso;

            return strkey;


            // tach rieng phan so va phan chu cua tham so id                  
            // giu nguyen phan chu
            // phan so chuyen di sang kieu so nguyen va tang them 1 don vi
            // ghep phan so voi phan chu de duoc ma tu sinh
            // tra ve ma sau khi tu sinh

        }

    }
}
