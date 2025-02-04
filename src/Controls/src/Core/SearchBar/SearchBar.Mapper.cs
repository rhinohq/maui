﻿#nullable disable
namespace Microsoft.Maui.Controls
{
	public partial class SearchBar
	{
		public static IPropertyMapper<ISearchBar, SearchBarHandler> ControlsSearchBarMapper =
			new PropertyMapper<SearchBar, SearchBarHandler>(SearchBarHandler.Mapper)
			{
#if IOS
				[PlatformConfiguration.iOSSpecific.SearchBar.SearchBarStyleProperty.PropertyName] = MapSearchBarStyle,
#endif
				[nameof(Text)] = MapText,
				[nameof(TextTransform)] = MapText,
			};

		internal static new void RemapForControls()
		{
			// Adjust the mappings to preserve Controls.SearchBar legacy behaviors
			SearchBarHandler.Mapper = ControlsSearchBarMapper;

#if ANDROID
			SearchBarHandler.CommandMapper.PrependToMapping(nameof(ISearchBar.Focus), MapFocus);
#endif
		}
	}
}
