框架说明
1

使用说明
1 添加现有项目 Spring.Aop 和 Spring.Core 的时候需要把 CommonAssemblyInfo.cs 文件复制到项目文件夹所在目录
2 Spring.Net Projects use MSBuild-Integrated package restore typically contain a .nuget folder with three files: NuGet.Config NuGet.exe NuGet.targets, NuGet has a feature called package restore. You need to enable that feature explicitly by right-clicking your solution and invoking the Enable NuGet Package Restore menu item
3 拷贝 config 文件夹到使用 AopGlobal 项目的输出路径
4 在使用 AopGlobal 项目的配置文件中加入如下配置
  <configSections>
    <sectionGroup name="spring">
      <section name="context" type="Spring.Context.Support.ContextHandler, Spring.Core"/>
      <section name="objects" type="Spring.Context.Support.DefaultSectionHandler, Spring.Core"/>
    </sectionGroup>
  </configSections>

  <spring>
    <context>
      <resource uri="~/config/Aop.xml" />
      <resource uri="~/config/Object.xml" />
    </context>
  </spring>