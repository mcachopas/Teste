using Teste.Models;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Teste.Droid.DadosEspecificos))]

namespace Teste.Droid
{
    public class DadosEspecificos : IDadosespecificos
    {
        public string CaminhoDB(string NomeDB)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), NomeDB);
        }
    }
}