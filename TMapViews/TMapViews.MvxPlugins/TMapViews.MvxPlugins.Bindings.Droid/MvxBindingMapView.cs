﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using TMapViews.Droid.Adapters;
using TMapViews.Droid.Models;
using TMapViews.Droid.Views;
using TMapViews.Models;

namespace TMapViews.MvxPlugins.Bindings.Droid
{
    public class MvxBindingMapView : BindingMapView
    {
        public new MvxBindingMapViewAdapter Adapter
        {
            get => base.Adapter as MvxBindingMapViewAdapter;
            private set => base.Adapter = value;
        }

        public MvxBindingMapView(Context context) : base(context)
        {
        }

        public MvxBindingMapView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public MvxBindingMapView(Context context, GoogleMapOptions options) : base(context, options)
        {
        }

        public MvxBindingMapView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        protected MvxBindingMapView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public int Initialize(Activity context, MvxBindingMapViewAdapter adapter, Bundle savedInstanceState = null)
        {
            return base.Initialize(context, adapter, savedInstanceState);
        }

        /// <summary>
        /// This is not compatible with MvxBindingMapView, please use
        /// Initialize(Activity context, MvxBindingMapViewAdapter adapter, Bundle
        /// savedInstanceState = null) instead;
        /// </summary>
        /// <param name="context">           </param>
        /// <param name="adapter">           </param>
        /// <param name="savedInstanceState"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int Initialize(Activity context, IBindingMapAdapter adapter, Bundle savedInstanceState = null) => throw new NotSupportedException("Please Use  Initialize(Activity context, MvxBindingMapViewAdapter adapter, Bundle savedInstanceState = null)");

        public override void AddAnnotation(IBindingMapAnnotation annotation)
        {
            if (annotation is IBindingMapAnnotation mMarker)
            {
                var markerOptions = Adapter.GetMarkerOptionsForPin(annotation);
                if (markerOptions != null)
                {
                    var marker = GoogleMap.AddMarker(markerOptions);
                    Adapter.GetMvxBindingMarker(marker, annotation);
                    marker.Tag = new AnnotationTag
                    {
                        Annotation = annotation
                    };
                    if (_markers == null)
                        _markers = new List<Marker>();
                    _markers.Add(marker);
                }
            }
        }
    }
}