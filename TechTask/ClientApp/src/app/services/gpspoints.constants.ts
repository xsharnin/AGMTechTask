export const ApplicationName = 'TechTask';

export const ReturnUrlType = 'returnUrl';

export const QueryParameterNames = {
  FromLat: 'fromLat',
  ToLat: 'toLat',
  FromLng: 'fromLng',
  ToLng: 'toLng'
};

export const GpsDataActions = {
  GetInitialPoints: '',
  GetBoundPoints: 'zoom'
};

let applicationPaths: ApplicationPathsType = {
  DefaultLoginRedirectPath: '/',
  GetInitialPoints: `gpspoint/`,
  GetBoundPoints: `gpspoint/${GpsDataActions.GetBoundPoints}/`
};

interface ApplicationPathsType {
  readonly DefaultLoginRedirectPath: string;
  readonly GetInitialPoints: string;
  readonly GetBoundPoints: string;
}

export const ApplicationPaths: ApplicationPathsType = applicationPaths;
