# lua-game-engine
Simple lua game engine

# Preview
- Inspired from entity style programming

  ```lua
  local monster = gameObject()
  monster.start.add(function()
    -- load stuff ..
  end)

  monster.update.add(function(deltaTime)
    -- do something ..
  end)
  ```

- Fully support [Lua5.4](https://www.lua.org/about.html) modules like `require`

- Classy & easy grammer using lua
  ```lua
  local myPanel = panel(){
    width = 100,
    height = 100,
    color = color.red
  }
  ```
  
# License
MIT by [vin-spiegel](https://github.com/vin-spiegel)
