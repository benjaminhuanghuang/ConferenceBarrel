# From Start to Finish: ASP.NET Core, Entity Framework Core and Visual Studio Code

    https://www.youtube.com/watch?v=TZF46oPBHPc
    

1. Install .NET Core

2. To use yeoman, need Node.js. To install Node.js, need NVM (node version manager)
$ crul -o- https://…../install.sh | bash
restart the terminal
$ nvm ls-remote       # list all version of Node.js
$ nvm install 4.4.7     # install node.js
$ npm install -g npm    # install npm

3. Install packages
$ npm install -g yo bower grunt-cli gulp generator-aspnet

4. Create project
$ yo aspnet

5. Install VS Code
$sudo dpkg -i  XXX.deb
Ctl(CMD)+shit+p

Add dependency in project.json (.net core1.0)
"Microsoft.EntitiyFrameworkCore": "1.0.0",
    "Microsoft.EntitiyFrameworkCore.Sqlite": "1.0.0",
    "Microsoft.EntitiyFrameworkCore.Design": {
      "version": "1.0.0",
      "type": "build"
    }


Add dependency in .csproj (.net core 1.1)        
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version= "1.1.1"/>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version= "1.1.1"/>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version= "1.1.0"/>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version= "1.0.0"/>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite.Design" Version= "1.1.1"/>

And tools in .csproj
<ItemGroup>
    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Design" Version="1.1.1" />
    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools" Version="1.1.0" />
    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="1.0.0" />
  </ItemGroup>
Run 
dotnet ef migrations add Initial 
This command use the tools added in .csproj file

Apply the migration
$ dotnet ef database update
Create /ConferenceBarrel/bin/Debug/netcoreapp1.1/confbarrel.db

Install Sqlite3
$ brew install sqlite3

Enter the folder of db file, and Run 
$ sqlite3 confbarrel.db
sqlite> .tables         # display all tables


