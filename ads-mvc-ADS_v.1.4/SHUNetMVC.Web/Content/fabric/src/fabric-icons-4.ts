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
      fontFamily: `"FabricMDL2Icons-4"`,
      src: `url('${baseUrl}fabric-icons-4-8ff945c2.woff') format('woff')`
    },
    icons: {
      'ChromeBack': '\uE830',
      'ChromeBackMirrored': '\uEA47',
      'ChromeClose': '\uE8BB',
      'ChromeFullScreen': '\uE92D',
      'ChromeMinimize': '\uE921',
      'ChromeRestore': '\uE923',
      'CircleAddition': '\uF2E3',
      'CircleAdditionSolid': '\uF2E4',
      'CircleDollar': '\uEAED',
      'CircleFill': '\uEA3B',
      'CircleHalfFull': '\uED9E',
      'CirclePause': '\uF2D9',
      'CirclePauseSolid': '\uF2D8',
      'CirclePlus': '\uEAEE',
      'CircleRing': '\uEA3A',
      'CircleShape': '\uF1A5',
      'CircleShapeSolid': '\uF63C',
      'CircleStop': '\uF2DC',
      'CircleStopSolid': '\uF2DB',
      'CityNext': '\uEC06',
      'CityNext2': '\uEC07',
      'ClassNotebookLogo16': '\uF488',
      'ClassNotebookLogo32': '\uF486',
      'ClassNotebookLogoFill16': '\uF489',
      'ClassNotebookLogoFill32': '\uF487',
      'ClassNotebookLogoInverse': '\uEDC8',
      'ClassNotebookLogoInverse16': '\uF48B',
      'ClassNotebookLogoInverse32': '\uF48A',
      'ClassroomLogo': '\uEF75',
      'Clear': '\uE894',
      'ClearFilter': '\uEF8F',
      'ClearFormatting': '\uEDDD',
      'ClearFormattingA': '\uF79D',
      'ClearFormattingEraser': '\uF79E',
      'ClearNight': '\uE9C2',
      'ClearSelection': '\uE8E6',
      'ClearSelectionMirrored': '\uEA48',
      'Clicked': '\uF268',
      'ClinicalImpression': '\uE54B',
      'Clipboard': '\uED22',
      'ClipboardList': '\uF0E3',
      'ClipboardListAdd': '\uE4EF',
      'ClipboardListMirrored': '\uF0E4',
      'ClipboardListQuestion': '\uE4F0',
      'ClipboardListReply': '\uE4F1',
      'ClipboardSolid': '\uF5DC',
      'Clock': '\uE917',
      'CloneToDesktop': '\uF28C',
      'ClosedCaption': '\uEF84',
      'ClosePane': '\uE89F',
      'ClosePaneMirrored': '\uEA49',
      'Cloud': '\uE753',
      'CloudAdd': '\uECA9',
      'CloudDownload': '\uEBD3',
      'CloudEdit': '\uE4C8',
      'CloudFlow': '\uE5EA',
      'CloudImportExport': '\uEE55',
      'CloudLink': '\uE4C9',
      'CloudNotSynced': '\uEC9C',
      'CloudPrinter': '\uEDA6',
      'CloudSearch': '\uEDE4',
      'CloudSecure': '\uE4D5',
      'CloudUpload': '\uEC8E',
      'CloudWeather': '\uE9BE',
      'Cloudy': '\uE9BF',
      'Cocktails': '\uEA9D',
      'Code': '\uE943',
      'CodeEdit': '\uF544',
      'Coffee': '\uEAEF',
      'CoffeeScript': '\uF2FA',
      'CollapseAll': '\uF85A',
      'CollapseContent': '\uF165',
      'CollapseContentSingle': '\uF166',
      'CollapseMenu': '\uEF66',
      'CollegeFootball': '\uEB26',
      'CollegeHoops': '\uEB25',
      'Color': '\uE790',
      'ColorSolid': '\uF354',
      'Column': '\uE438',
      'ColumnFunction': '\uE4C2',
      'ColumnLeftTwoThirds': '\uF1D6',
      'ColumnLeftTwoThirdsEdit': '\uF324',
      'ColumnList': '\uF1EC',
      'ColumnOptions': '\uF317',
      'ColumnQuestion': '\uE4C0',
      'ColumnQuestionMirrored': '\uE4C1',
      'ColumnRightTwoThirds': '\uF1D7',
      'ColumnRightTwoThirdsEdit': '\uF325',
      'ColumnSigma': '\uE4BF',
      'ColumnVerticalSection': '\uF81E',
      'ColumnVerticalSectionEdit': '\uF806',
      'Combine': '\uEDBB',
      'Combobox': '\uF516',
      'CommandPrompt': '\uE756',
      'Comment': '\uE90A',
      'CommentActive': '\uF804',
      'CommentAdd': '\uF2B3',
      'CommentNext': '\uF2B4',
      'CommentPrevious': '\uF2B5',
      'CommentSolid': '\uE30E'
    }
  };

  registerIcons(subset, options);
}
