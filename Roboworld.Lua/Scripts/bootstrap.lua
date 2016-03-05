baseUrl = "http://localhost/Roboworld.Gateway.WebApi/software/"
print("Bootstrapper V1.2")
print("-----------------")

local files = getFilesToUpdate(baseUrl)
for k, v in ipairs(files.Libraries) do
    local fileUrl = "library/" .. v.Name
    local filename = "lib/" .. v.Name
    local content = httpGetPlainText(baseUrl .. fileUrl)
    saveToDisk(filename, content)
    print(" - saved '" .. filename .. "'")
end
for k, v in ipairs(files.Scripts) do
    local fileUrl = "script/" .. v.Name
    local filename = v.Name
    local content = httpGetPlainText(baseUrl .. fileUrl)
    saveToDisk(filename, content)
    print(" - saved '" .. filename .. "'")
end
print("All software downloaded")