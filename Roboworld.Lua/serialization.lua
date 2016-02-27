function tableValuesToJson(source)
    local json = { "[" }
    for k, v in ipairs(source) do
        if (type(v) == "string") then
            json[#json + 1] = "\""
            json[#json + 1] = v
            json[#json + 1] = "\""
        else
            json[#json + 1] = tostring(v)
        end
        json[#json + 1] = ","
    end
    json[#json] = "]"
    return table.concat(json)
end

function tablePairsToJson(source)
    local json = { "{" }
    for k, v in pairs(source) do
            json[#json + 1] = "\""
            json[#json + 1] = k
            json[#json + 1] = "\":"

        if (type(v) == "string") then
            json[#json + 1] = "\""
            json[#json + 1] = v
            json[#json + 1] = "\""
        else
            json[#json + 1] = tostring(v)
        end
        json[#json + 1] = ","
    end
    json[#json] = "}"
    return table.concat(json)
end
