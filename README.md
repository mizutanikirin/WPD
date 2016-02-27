#WPD
C#のWindows Portable Device(WPD)のプログラム。複数のデジカメ(Nikon D3300)の写真をローカルの指定したフォルダに保存し、その後にデジカメ内の写真を削除します。

詳しい説明は『[C# - デジカメの写真をローカルにコピーする方法 | MIZUATNI KIRIN](http://wp.me/p7cL0D-qQ)』をご覧ください。


* フォルダの場所を変更する場合はProgram.csのdevice.DownloadFileの引数を変更してください。
* 接続台数、IDを変更する場合はPortableDeviceCollection.cs内のdeviceIds配列を変更してください。
