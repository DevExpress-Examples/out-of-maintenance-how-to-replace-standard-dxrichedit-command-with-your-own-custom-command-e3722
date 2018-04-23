# How to replace standard DXRichEdit command with your own custom command


<p>This example illustrates the technique used to modify the functionality of existing XtraRichEdit commands.<br />
The RichEditControl exposes the <a href="http://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditServicesIRichEditCommandFactoryServicetopic"><u>IRichEditCommandFactoryService</u></a> interface that enables you to substitute default command with your own custom command. <br />
To accomplish a command substitution, perform the following steps. Create a command class, inherited from the command that you've decided to replace. Override its methods. The main functionality and command specifics  is located in the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressUtilsCommandsCommand_Executetopic"><u>Execute</u></a> or the<strong> ExecuteCore</strong> method (the latter does not check for the command availability). Then, create a class named CustomRichEditCommandFactoryService which implements the IRichEditCommandFactoryService interface. You should override its CreateCommand method to create an instance of a custom command class if an identifier of a certain command is passed as a parameter. So, instead of the default command, a custom command will be used by the RichEditControl. Finally the CustomRichEditCommandFactoryService class  substitutes a default RichEditControl's service.</p><br />


<br/>


