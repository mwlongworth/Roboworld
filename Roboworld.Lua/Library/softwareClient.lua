function getFilesToUpdate(baseUrl)
    return httpGetTable(baseUrl.."update")
end
function getSoftwareToUpdate(baseUrl)
    return httpGetTable(baseUrl.."update2")
end