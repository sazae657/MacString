macString
================================

## macString

非 Mac 環境でも NFD が気軽に楽しめます

macOS の仕様に従いU+2000-U+2FFF、U+F900 - U+FAFF、U+2F800-U+2FAFFの分解は行わないので、より mac 度の高い文字列が生成できます

## Usage

    using MacString;

    var str = "マックで読みやすいもじれつ";

    System.Console.WriteLine($"{str} => {str.ToMac()}");
    System.Console.WriteLine("実際の濁点/半濁点はNFD仕様の0x3099/309Aで出力されます".ToMac());
    // マックで読みやすいもじれつ => マックて゛読みやすいもし゛れつ
    // 実際の濁点/半濁点はNFD仕様の0x3099/309Aて゛出力されます


### 革新モード

引数に `MacStringOption.InnovativeCombining` を与えると革新モードになります

革新モードでは合成文字を非合成文字で出力します

    using MacString;

    var str = "マックで読みやすいもじれつ";

	System.Console.WriteLine($"{str} => {str.ToMac(MacStringOption.InnovativeCombining)}");
	// マックで読みやすいもじれつ => マックて゛読みやすいもし゛れつ

## License

[MIT License](https://gawanative.com/MIT.txt)
