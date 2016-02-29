baseUrl = "http://localhost/Roboworld.Gateway.WebApi/software/"
print("Bootstrapper V1.1")
print("----------------")

local files = getFilesToUpdate(baseUrl)
for k, v in ipairs(files) do
    local fileUrl = "library/" .. v
    local filename = "lib/" .. v
    local content = httpGetPlainText(baseUrl .. fileUrl)
    saveToDisk(filename, content)
    print(" - saved '" .. filename .. "'")
end
print("All software downloaded")
local files = getSoftwareToUpdate(baseUrl)
for k, v in ipairs(files.Libraries) do
    print(" = Lib " .. v.Name .. " - " .. v.Version .. "'")
end
for k, v in ipairs(files.Scripts) do
    print(" = Script " .. v.Name .. " - " .. v.Version .. "'")
end
print("All software downloaded")