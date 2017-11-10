using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace SimpleWPF.Core.Core
{
    public sealed class SimpleDataTemplateManager
    {
        public void LoadDataTemplatesByConvention()
        {
            var assembly = Assembly.GetCallingAssembly();
            var assemblyTypes = assembly.GetTypes();

            var viewModels = assemblyTypes.Where(x => x.Name.Contains("ViewModel"));

            foreach (var vm in viewModels)
            {
                var baseName = vm.Name.Replace("ViewModel", string.Empty);

                var viewType = assemblyTypes.FirstOrDefault(x => x.Name == baseName + "View");

                if (viewType != null)
                    RegisterDataTemplate(vm, viewType);
            }
        }

        public void RegisterDataTemplate(Type viewModelType, Type viewType)
        {
            var template = CreateTemplate(viewModelType, viewType);
            Application.Current.Resources.Add(template.DataTemplateKey, template);
        }

        private DataTemplate CreateTemplate(Type viewModelType, Type viewType)
        {
            const string xamlTemplate = "<DataTemplate DataType=\"{{x:Type vm:{0}}}\"><v:{1} /></DataTemplate>";
            var xaml = String.Format(xamlTemplate, viewModelType.Name, viewType.Name, viewModelType.Namespace, viewType.Namespace);
            var context = new ParserContext();
            Console.WriteLine(xaml);
            context.XamlTypeMapper = new XamlTypeMapper(new string[0]);
            context.XamlTypeMapper.AddMappingProcessingInstruction("vm", viewModelType.Namespace, viewModelType.Assembly.FullName);
            context.XamlTypeMapper.AddMappingProcessingInstruction("v", viewType.Namespace, viewType.Assembly.FullName);

            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            context.XmlnsDictionary.Add("vm", "vm");
            context.XmlnsDictionary.Add("v", "v");

            var template = (DataTemplate)XamlReader.Parse(xaml, context);
            return template;
        }
    }
}
