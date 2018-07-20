﻿using System;
using CoreGraphics;
using Foundation;
using MapKit;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using TMapViews.iOS.Models;
using TMapViews.Models;

namespace TMapViews.MvxPlugins.Bindings.iOS
{
    public abstract class MvxBindingMKAnnotationView : MKAnnotationView, IMvxBindable
    {
        private string _reuseIdentifier;

        public override string ReuseIdentifier { get => _reuseIdentifier; }

        public new BindingMKAnnotation Annotation
        {
            get => base.Annotation as BindingMKAnnotation;
            set
            {
                base.Annotation = value;
                OnAnnotationSet();
            }
        }

        public MvxBindingMKAnnotationView()
        {
            this.CreateBindingContext(string.Empty);
        }

        public MvxBindingMKAnnotationView(string reuseIdentifier)
        {
            _reuseIdentifier = reuseIdentifier;
            this.CreateBindingContext(string.Empty);
        }

        public IMvxBindingContext BindingContext { get; set; }

        public object DataContext
        {
            get => BindingContext.DataContext;
            set
            {
                if (value is IBindingMapAnnotation val)
                {
                    Annotation = new BindingMKAnnotation(val);
                    BindingContext.DataContext = val;
                }
            }
        }

        public virtual void OnAnnotationSet()
        {
        }
    }
}