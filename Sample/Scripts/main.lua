local debug = {
    print = function(obj)
        print(tostring(obj))
    end
}

print("Hello World")
print("3 초 뒤 실행")



--[[ Point Struct ]]
local a, b = point(1,1), point(2,2)
debug.print(a + b)
debug.print(a - b)
debug.print(a * b)
debug.print(a / b)
debug.print(a == b)
--]]

--[[ Color Struct ]]
print(color.black.r)
print(color.black.g)
print(color.black.b)
print(color.black.a)
print(color.black[1])

print(typeof(point))
print(typeof(a))

print(deltaTime)

print(entity)


local monster = entity()

local s = 0
local t = 0

monster.update.add(function(dt)
    s = s + dt
    t = t + time.deltaTime
    
    if (s > 2) then
        print(s, t)
        s = 0
        t = 0
    end
end)

--local t = 0
--while(true) do
--    t = t + time.deltaTime
--
--    if (t > 2) then
--        t = 0
--        print("2초 경과")
--    end
--end 