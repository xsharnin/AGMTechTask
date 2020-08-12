import { Injectable, Inject } from '@angular/core';
import { BehaviorSubject, concat, from, Observable } from 'rxjs';
import { filter, map, mergeMap, take, tap } from 'rxjs/operators';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ApplicationPaths, QueryParameterNames, GpsDataActions } from './gpspoints.constants';

interface GpsPoint {
  lng: number;
  lat: number;
  count: number;
}

@Injectable({
  providedIn: 'root'
})
export class GpsPointsService {
  
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  }

  public async GetInitialPoints(): Promise<GpsPoint[]>
  {
    try {
      return await this.httpClient.get<GpsPoint[]>(ApplicationPaths.GetInitialPoints).toPromise();
    }
    catch (error) {
      console.log('Get exception on calling for GPSPoints: ', error);
      return null;
    }
  }

  public async GetBoundPoints(zoom: string, fromLat: string, toLat: string, fromLng: string, toLng: string): Promise<GpsPoint[]> {
    try {
      let parameters = new HttpParams()
        .append(QueryParameterNames.FromLat, fromLat)
        .append(QueryParameterNames.ToLat, toLat)
        .append(QueryParameterNames.FromLng, fromLng)
        .append(QueryParameterNames.ToLng, toLng);
      return await this.httpClient.get<GpsPoint[]>(ApplicationPaths.GetBoundPoints.replace(GpsDataActions.GetBoundPoints, zoom), { params: parameters }).toPromise();
    } catch (error) {
      console.log('Get exception on calling for GPSPoints: ', error);
      return null;
    }
  }
}
