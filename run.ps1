Add-Type -path ".\Program.cs" `
	-ReferencedAssemblies System.Data `
	-OutputAssembly pg.exe `
	-OutputType ConsoleApplication

Read-Host "何かキーを押してください"
