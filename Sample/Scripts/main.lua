local debug = {
    print = function(obj)
        print(tostring(obj))
    end
}
print("Start Window")
wait(4)

--[[ Window Cycle ]]
window.load = function()
    print("loaded window")
end
window.update = function(dt)
    --print(dt)
end
--]]


--[[ Point Struct ]]
local a, b = point(1,1), point(2,2)
debug.print(a + b)
debug.print(a - b)
debug.print(a * b)
debug.print(a / b)
debug.print(a == b)
debug.print(point.distance(a, b))
--]]