import { Component, Inject } from '@angular/core';
import { GoogleMapsAPIWrapper, AgmMap, LatLngBounds, LatLngLiteral, LatLng } from '@agm/core';
import { GpsPointsService } from '../services/gpspoints.service';

declare var google: any;


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.component.css']
})
export class FetchDataComponent {

  constructor(
    private gpspointsservice: GpsPointsService) { }

  // google maps zoom level
  zoom: number = 8;

  // initial center position for the map
  lat: number = 40.762428283691406;
  lng: number = -73.971176147460938;

  fitBounds: LatLngBounds;

  clickedMarker(label: string, index: number) {
    console.log(`clicked the marker: ${index}`)
  }

  zoomChange(zoom: number) {
    this.zoom = zoom;
    console.log(`zoom changed to: ${zoom}`)
  }

  boundsChange(data: LatLngBounds) {
    console.log(`boundsChange to NE ${data.getNorthEast().lng()},${data.getNorthEast().lat()}
                to SW ${data.getSouthWest().lng()}, ${data.getSouthWest().lat()}`)
    if (this.zoom>8)
      this.setBoundPoints(data);
  }

  centerChanged(data: LatLngLiteral) {
    console.log(`centerChanged to: ${data}`)
  }

  idle() {
    console.log(`idle  to: ${this}`)
  }

  mapReady(map: AgmMap) {
    this.setInitialPoints();
    console.log(`mapReady `)

  }

  markers: GpsPoint[];

  private async setInitialPoints() {
    this.markers = await this.gpspointsservice.GetInitialPoints();
    await this.SetBounds();
  }

  private async setBoundPoints(newBounds: LatLngBounds) {
    this.markers = await this.gpspointsservice.GetBoundPoints(
      this.zoom.toString(),
      newBounds.getSouthWest().lat().toString(),
      newBounds.getNorthEast().lat().toString(),
      newBounds.getSouthWest().lng().toString(),
      newBounds.getNorthEast().lng().toString());
  }

  private async SetBounds(): Promise<void>
  {      
    console.log(`start bounding`)
    const bounds: LatLngBounds = new google.maps.LatLngBounds();
    for (const mm of this.markers) {
      bounds.extend(new google.maps.LatLng(mm.lat, mm.lng));
    }
    this.fitBounds = bounds;
    console.log(`finished bounding`); 
  }
}

interface GpsPoint {
  lat: number;
  lng: number;
}
