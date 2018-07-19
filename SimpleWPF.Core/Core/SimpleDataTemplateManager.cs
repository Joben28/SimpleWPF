using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace SimpleWPF.Core.Core
{
    /// <summary>
    /// A management object for loading data templates
    /// </summary>
    public sealed class SimpleDataTemplateManager
    {
        /// <summary>
        /// Load assembly object and register data templates based on naming convention, e.g., FooViewModel --> FooView
        /// </summary>
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

        /// <summary>
        /// Register a data template
        /// </summary>
        /// <typeparam name="VM">ViewModel type</typeparam>
        /// <typeparam name="V">View Type</typeparam>
        public void RegisterDataTemplate<VM, V>()
        {
            var template = CreateTemplate(typeof(VM), typeof(V));
            Application.Current.Resources.Add(template.DataTemplateKey, template);
        }

        /// <summary>
        /// Register a data template
        /// </summary>
        /// <param name="viewModel">ViewModel type</param>
        /// <param name="view">View Type</param>
        public void RegisterDataTemplate(Type viewModel, Type view)
        {
            var template = CreateTemplate(viewModel, view);
            Application.Current.Resources.Add(template.DataTemplateKey, template);
        }

        //Maps data templates (http://www.ikriv.com/dev/wpf/DataTemplateCreation/)
        private DataTemplate CreateTemplate(Type viewModelType, Type viewType)
        {
            const string xamlTemplate = "<DataTemplate DataType=\"{{x:Type vm:{0}}}\"><v:{1} /></DataTemplate>";
            var xaml = String.Format(xamlTemplate, viewModelType.Name, viewType.Name, viewModelType.Namespace, viewType.Namespace);
            var context = new ParserContext();
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