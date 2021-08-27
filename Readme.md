<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128606690/11.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3722)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [CustomCommand.cs](./CS/CustomCommand/CustomCommand.cs) (VB: [CustomCommand.vb](./VB/CustomCommand/CustomCommand.vb))
* [MainPage.xaml](./CS/CustomCommand/MainPage.xaml) (VB: [MainPage.xaml](./VB/CustomCommand/MainPage.xaml))
* [MainPage.xaml.cs](./CS/CustomCommand/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/CustomCommand/MainPage.xaml.vb))
<!-- default file list end -->
# How to replace standard DXRichEdit command with your own custom command


<p>This example illustrates the technique used to modify the functionality of existing XtraRichEdit commands.<br />
The RichEditControl exposes the <a href="http://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditServicesIRichEditCommandFactoryServicetopic"><u>IRichEditCommandFactoryService</u></a> interface that enables you to substitute default command with your own custom command. <br />
To accomplish a command substitution, perform the following steps. Create a command class, inherited from the command that you've decided to replace. Override its methods. The main functionality and command specifics  is located in the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressUtilsCommandsCommand_Executetopic"><u>Execute</u></a> or the<strong> ExecuteCore</strong> method (the latter does not check for the command availability). Then, create a class named CustomRichEditCommandFactoryService which implements the IRichEditCommandFactoryService interface. You should override its CreateCommand method to create an instance of a custom command class if an identifier of a certain command is passed as a parameter. So, instead of the default command, a custom command will be used by the RichEditControl. Finally the CustomRichEditCommandFactoryService class  substitutes a default RichEditControl's service.</p><br />


<br/>


