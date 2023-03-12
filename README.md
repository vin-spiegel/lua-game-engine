# lua-game-engine
Simple lua game engine

# Dependency
- [SFML.Net](https://github.com/SFML/SFML.Net)
- [MoonSharp](https://github.com/moonsharp-devs/moonsharp)

# Preview
- Inspired from [Entity Component System](https://en.wikipedia.org/wiki/Entity_component_system)

  ```lua
  local monster = gameObject()
  monster.start.add(function()
    -- load stuff ..
  end)

  monster.update.add(function(deltaTime)
    -- do something ..
  end)
  ```
- Fully support [Lua5.4](https://www.lua.org/about.html) modules like `require` keyword

- Easy grammer with lua
  ```lua
  local myPanel = panel(){
    width = 100,
    height = 100,
    color = color.red
  }
  ```
  
# Document
  comming soon...
  
# License
MIT by [vin-spiegel](https://github.com/vin-spiegel)
