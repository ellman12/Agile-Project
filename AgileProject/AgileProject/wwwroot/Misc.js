//Get if this device is a phone.
//https://www.syncfusion.com/faq/blazor/javascript-interop/how-do-you-detect-whether-a-page-is-loaded-in-mobile-or-on-desktop
function isMobile() {
    return /android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini|mobile/i.test(navigator.userAgent);
}