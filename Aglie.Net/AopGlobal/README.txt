���˵��
1

ʹ��˵��
1 ���������Ŀ Spring.Aop �� Spring.Core ��ʱ����Ҫ�� CommonAssemblyInfo.cs �ļ����Ƶ���Ŀ�ļ�������Ŀ¼
2 Spring.Net Projects use MSBuild-Integrated package restore typically contain a .nuget folder with three files: NuGet.Config NuGet.exe NuGet.targets, NuGet has a feature called package restore. You need to enable that feature explicitly by right-clicking your solution and invoking the Enable NuGet Package Restore menu item
3 ���� config �ļ��е�ʹ�� AopGlobal ��Ŀ�����·��
4 ��ʹ�� AopGlobal ��Ŀ�������ļ��м�����������
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