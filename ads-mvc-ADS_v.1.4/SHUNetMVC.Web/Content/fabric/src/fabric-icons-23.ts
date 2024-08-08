  // Your use of the content in the files referenced here is subject to the terms of the license at https://aka.ms/fabric-assets-license

// tslint:disable:max-line-length

import {
  IIconOptions,
  IIconSubset,
  registerIcons
} from '@uifabric/styling';

export function initializeIcons(
  baseUrl: string = '',
  options?: IIconOptions
): void {
  const subset: IIconSubset = {
    style: {
      MozOsxFontSmoothing: 'grayscale',
      WebkitFontSmoothing: 'antialiased',
      fontStyle: 'normal',
      fontWeight: 'normal',
      speak: 'none'
    },
    fontFace: {
      fontFamily: `"FabricMDL2Icons-23"`,
      src: `url('${baseUrl}fabric-icons-23-f471823a.woff') format('woff')`
    },
    icons: {
      'World': '\uE909',
      'WorldClock': '\uE918',
      'XPowerY': '\uF7CA',
      'XRay': '\uE551',
      'YammerLogo': '\uED19',
      'ZeroDayCalendar': '\uE547',
      'ZeroDayPatch': '\uE665',
      'ZipFolder': '\uF012',
      'Zoom': '\uE71E',
      'ZoomIn': '\uE8A3',
      'ZoomOut': '\uE71F',
      'ZoomToFit': '\uF649',
      'ZoomToFitAlt': '\uE693'
    }
  };

  registerIcons(subset, options);
}
