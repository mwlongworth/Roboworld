baseUrl = "http://localhost/Roboworld.Gateway.WebApi/software/"
print("Boostrapper V1.1")
print("----------------")

local files = getFilesToUpdate(baseUrl)
for k, v in ipairs(files) do
    local fileUrl = "library/"..v
    local filename = "lib/"..v
    local content = httpGetPlainText(baseUrl..fileUrl)
    saveToDisk(filename,content)
    print(" - saved '" .. filename .. "'")
end
print("All software downloaded")