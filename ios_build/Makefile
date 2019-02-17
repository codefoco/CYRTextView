.PHONY: all

all: ios

ios: ./ios/libCYRTextView.framework/libCYRTextView
./ios/libCYRTextView.framework/libCYRTextView:
	xcodebuild  -project CYRTextView.xcodeproj -configuration Release -sdk iphonesimulator
	xcodebuild  -project CYRTextView.xcodeproj -configuration Release -sdk iphoneos
	ditto ./Build/Release-iphoneos/ ./ios/
	rm ./ios/libCYRTextView.framework/libCYRTextView
	lipo -create ./build/Release-iphonesimulator/libCYRTextView.framework/libCYRTextView  ./build/Release-iphoneos/libCYRTextView.framework/libCYRTextView -output  ./ios/libCYRTextView.framework/libCYRTextView
	/usr/libexec/PlistBuddy -c "Add :CFBundleSupportedPlatforms: string iPhoneSimulator" ./ios/libCYRTextView.framework/Info.plist

clean:
	rm -Rf build
	rm -Rf ./ios/