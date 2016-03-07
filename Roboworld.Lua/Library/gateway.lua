if web==nil then error("please load the 'web' api") end

function getCommand()
    return web.getText("http://localhost/Roboworld.Gateway.WebApi/robot/command")
end