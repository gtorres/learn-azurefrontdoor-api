function getFormattedResourceNameCommon(){
    local noDash=${1//-/}
    local noDot=${noDash//./}
    echo "$noDot"
}
