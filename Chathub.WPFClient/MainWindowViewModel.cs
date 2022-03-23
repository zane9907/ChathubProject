using Chathub.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chathub.WPFClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Message> Messages { get; set; }


        public Message NewMessage { get; set; }

        public ICommand SendMessageCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Messages = new RestCollection<Message>("http://localhost:43829", "message", "hub");
                SendMessageCommand = new RelayCommand(() =>
                {
                    Messages.Add(new Message()
                    {
                        Username = NewMessage.Username,
                        Content = NewMessage.Content,
                        Date = DateTime.Now
                    });
                });

                NewMessage = new Message();
            }
        }
    }
}
