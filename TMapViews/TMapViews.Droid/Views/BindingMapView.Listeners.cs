﻿using Android.Gms.Maps.Model;
using Android.Locations;
using TMapViews.Droid.Models;
using TMapViews.Models;
using static Android.Gms.Maps.GoogleMap;

namespace TMapViews.Droid.Views
{
    public partial class BindingMapView :
        IOnCameraMoveListener,
        IOnMapClickListener,
        IOnMapLongClickListener,
        IOnMarkerClickListener,
        IOnMarkerDragListener,
        IOnMyLocationButtonClickListener,
        IOnMyLocationClickListener,
        IOnCircleClickListener,
        IOnGroundOverlayClickListener,
        IOnPolygonClickListener,
        IOnPolylineClickListener
    {
        private void SetListeners()
        {
            GoogleMap.SetOnCameraMoveListener(this);
            GoogleMap.SetOnMapClickListener(this);
            GoogleMap.SetOnMapLongClickListener(this);
            GoogleMap.SetOnMarkerClickListener(this);
            GoogleMap.SetOnMarkerDragListener(this);
            GoogleMap.SetOnMyLocationButtonClickListener(this);
            GoogleMap.SetOnMyLocationClickListener(this);
            GoogleMap.SetOnCircleClickListener(this);
            GoogleMap.SetOnGroundOverlayClickListener(this);
            GoogleMap.SetOnPolygonClickListener(this);
            GoogleMap.SetOnPolylineClickListener(this);
        }

        public virtual bool OnMarkerClick(Marker marker)
        {
            var mAnnotation = (marker.Tag as AnnotationTag)?.Annotation;
            if (mAnnotation is IBindingMapAnnotation anno
                && (MarkerClick?.CanExecute(anno) ?? false))
            {
                MarkerClick.Execute(anno);
                return true;
            }
            return false;
        }

        private void OnLocationChanged(object sender, MyLocationChangeEventArgs e)
        {
            var loc = e.Location.ToBinding3DLocation();
            UserLocation = loc;
            if (LocationChanged?.CanExecute(loc) ?? false)
                LocationChanged.Execute(loc);
        }

        public void OnMapClick(LatLng point)
        {
            var loc = point.ToBinding2DLocation();
            if (MapClick?.CanExecute(loc) ?? false)
                MapClick.Execute(loc);
        }

        public void OnCameraMove()
        {
            var loc = new Binding3DLocation(
                latitude: GoogleMap.CameraPosition.Target.Latitude,
                longitude: GoogleMap.CameraPosition.Target.Longitude,
                altitude: GoogleMap.CameraPosition.Zoom
            );
            if (CameraMoved?.CanExecute(loc) ?? false)
                CameraMoved.Execute(loc);
        }

        public void OnMapLongClick(LatLng point)
        {
            var loc = point.ToBinding2DLocation();
            if (MapLongClick?.CanExecute(loc) ?? false)
                MapLongClick.Execute(loc);
        }

        public void OnMarkerDrag(Marker marker)
        {
            var mAnnotation = (marker.Tag as AnnotationTag).Annotation;
            if (mAnnotation is IBindingMapAnnotation anno)
            {
                anno.Location = marker.Position.ToBinding2DLocation();
                if (MarkerDrag?.CanExecute(anno) ?? false)
                {
                    MarkerDrag.Execute(anno);
                }
            }
        }

        public void OnMarkerDragEnd(Marker marker)
        {
            var mAnnotation = (marker.Tag as AnnotationTag).Annotation;
            if (mAnnotation is IBindingMapAnnotation anno)
            {
                anno.Location = marker.Position.ToBinding2DLocation();
                if (MarkerDragEnd?.CanExecute(anno) ?? false)
                {
                    MarkerDragEnd.Execute(anno);
                }
            }
        }

        public void OnMarkerDragStart(Marker marker)
        {
            var mAnnotation = (marker.Tag as AnnotationTag).Annotation;
            if (mAnnotation is IBindingMapAnnotation anno)
            {
                anno.Location = marker.Position.ToBinding2DLocation();
                if (MarkerDragStart?.CanExecute(anno) ?? false)
                {
                    MarkerDragStart.Execute(anno);
                }
            }
        }

        public bool OnMyLocationButtonClick()
        {
            if (MyLocationButtonClick?.CanExecute(null) ?? false)
            {
                MyLocationButtonClick.Execute(null);
                return true;
            }
            return false;
        }

        public void OnMyLocationClick(Location location)
        {
            var loc = location.ToBinding3DLocation();
            if (MyLocationClick?.CanExecute(loc) ?? false)
                MyLocationClick.Execute(loc);
        }

        public void OnCircleClick(Circle overlay)
        {
            var mAnnotation = (overlay.Tag as AnnotationTag)?.Annotation;
            if (mAnnotation is IBindingMapAnnotation anno
                && (OverlayClick?.CanExecute(anno) ?? false))
            {
                OverlayClick.Execute(anno);
            }
        }

        public void OnGroundOverlayClick(GroundOverlay overlay)
        {
            var mAnnotation = (overlay.Tag as AnnotationTag)?.Annotation;
            if (mAnnotation is IBindingMapAnnotation anno
                && (OverlayClick?.CanExecute(anno) ?? false))
            {
                OverlayClick.Execute(anno);
            }
        }

        public void OnPolygonClick(Polygon overlay)
        {
            var mAnnotation = (overlay.Tag as AnnotationTag)?.Annotation;
            if (mAnnotation is IBindingMapAnnotation anno
                && (OverlayClick?.CanExecute(anno) ?? false))
            {
                OverlayClick.Execute(anno);
            }
        }

        public void OnPolylineClick(Polyline overlay)
        {
            var mAnnotation = (overlay.Tag as AnnotationTag)?.Annotation;
            if (mAnnotation is IBindingMapAnnotation anno
                && (OverlayClick?.CanExecute(anno) ?? false))
            {
                OverlayClick.Execute(anno);
            }
        }
    }
}