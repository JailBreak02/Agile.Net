框架说明
1 修改配置文件实时生效 [assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4netConfig.xml", Watch = true)]
2 分时间(1小时)分大小(200M)记录日志文件 对应配置文件中 datePattern 和 maximumFileSize 参数
3 支持实时修改Level等级来记录不同等级的日志信息 对应配置文件中 levelMin 和 levelMax 参数

使用说明
1 拷贝 log4netConfig.xml 文件到使用log4net项目的输出路径