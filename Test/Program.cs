﻿using System;
using System.Data.Common;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace NgocThe

{
    public class Test
    {
        static void Change(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    System.Console.WriteLine("Bạn vừa thêm phần tử.");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    System.Console.WriteLine("Bạn vừa xóa phần tử.");
                    break;
            }
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            ObservableCollection<string> obs = new ObservableCollection<string>();
            obs.CollectionChanged += Change;
            obs.Add("1");
            obs.RemoveAt(0);
            Console.ReadKey();
        }
    }

}