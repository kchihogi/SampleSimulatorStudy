# SampleSimulatorStudy
Windows上で動作するキー操作をシミュレートするプログラム。
本リポジトリは教材として作成したものであり、実用性はありません。

## 使い方
TBD

## ダウンロード
TBD

## C#の開発環境を構築する
[手順](https://zenn.dev/midoliy/articles/9e3cff958ff89ba151de)を参照してください。
VSCodeを使用してC#の開発環境を構築することができます。
情報更新しないので、最新の情報は公式サイトを参照してください。

## ディレクトリ作成
コマンドプロンプトを開き、以下のコマンドを実行してください。
```cmd
mkdir KeySimulator
cd KeySimulator
```

## プロジェクトの作成
コマンドプロンプトを開き、以下のコマンドを実行してください。
```cmd
dotnet new console -o KeySimulator -f net7.0
dotnet new xunit -n KeySimulatorTest -o KeySimulatorTest -f net7.0
dotnet add KeySimulatorTest/KeySimulatorTest.csproj reference KeySimulator/KeySimulator.csproj
dotnet add KeySimulatorTest/KeySimulatorTest.csproj package coverlet.msbuild
dotnet new sln -n KeySimulator
dotnet sln KeySimulator.sln add KeySimulator/KeySimulator.csproj --in-root
dotnet sln KeySimulator.sln add KeySimulatorTest/KeySimulatorTest.csproj --in-root
```
KeySimulator/KeySimulator.csprojの内容を以下のように変更してください。
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net7.0-windows</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <UseWindowsForms>true</UseWindowsForms>
  </PropertyGroup>

</Project>
```
※TragetFrameworkの値を変更してください。
※UseWindowsFormsの値を追加してください。

KeySimulatorTest/KeySimulatorTest.csprojの内容を以下のように変更してください。(一部のみを抜粋しています。)
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net7.0-windows</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```
※TragetFrameworkの値を変更してください。

## プロジェクトのビルド
コマンドプロンプトを開き、以下のコマンドを実行してください。
```cmd
dotnet build
```

## プロジェクトの実行
コマンドプロンプトを開き、以下のコマンドを実行してください。
```cmd
dotnet run --project KeySimulator
```

## テストの実行
コマンドプロンプトを開き、以下のコマンドを実行してください。
```cmd
dotnet test
```

## テストのカバレッジを取得する
コマンドプロンプトを開き、以下のコマンドを実行してください。
```cmd
dotnet test /p:CollectCoverage=true
```

## デプロイを行う
コマンドプロンプトを開き、以下のコマンドを実行してください。
```cmd
dotnet publish -c Release -r win-x64 --self-contained true
powershell Compress-Archive -Path .\KeySimulator\bin\Release\net7.0-windows\win-x64 -DestinationPath .\KeySimulator.zip
```
成果物は、KeySimulator.zipとして作成されます。

## 実装
Programクラス、Dllクラス、Simulatorクラスの3つのクラスを作成します。
### Dllクラスの作成
キー操作をシミュレートするために、WindowsAPIを使用します。
DllImportを使用して、WindowsAPIを呼び出します。
そのためにDllクラスを作成します。
[Dll.cs](src/KeySimulator/KeySimulator/Dll.cs)を参照してください。
### Simulatorクラスの作成
キー操作をシミュレートするために、Simulatorクラスを作成します。
[Simulator.cs](src/KeySimulator/KeySimulator/Simulator.cs)を参照してください。
### Programクラスの作成
Simulatorクラスを使用して、キー操作をシミュレートします。
[Program.cs](src/KeySimulator/KeySimulator/Program.cs)を参照してください。

## テスト
Simulatorクラスのテストを作成します。
[SimulatorTest.cs](src/KeySimulatorTest/KeySimulatorTest/SimulatorTest.cs)を参照してください。
