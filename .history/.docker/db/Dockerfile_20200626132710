# escape=`
FROM  sixeyed/msbuild:netfx-4.5.2-ssdt AS builder

WORKDIR C:\src\dev.eduardroid.database
COPY src\dev.eduardroid.database .
RUN msbuild dev.eduardroid.database.sqlproj `
    /p.SQLDBExtensionsRefPath="C:\Microsoft.Data.Tools.Msbuild.10.0.61026\lib\net40" `
    /p.SqlServerRedistPath="C:\Microsoft.Data.Tools.Msbuild.10.0.61026\lib\net40"
