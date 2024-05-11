# Supply Signal
Call an airdrop in position with grenade like in Rust.

## Configuration
```xml
<?xml version="1.0" encoding="utf-8"?>
<SupplySignalConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <MessageColor>yellow</MessageColor>
  <MessageIconUrl>https://i.imgur.com/YBvLzj1.png</MessageIconUrl>
  <SupplyGrenadeId>265</SupplyGrenadeId>
  <AirdropDelay>5</AirdropDelay>
  <AirdropId>543</AirdropId>
  <AirdropSpeed>128</AirdropSpeed>
  <ShouldBroadcast>true</ShouldBroadcast>
</SupplySignalConfiguration>
```

## Translations
```xml
<?xml version="1.0" encoding="utf-8"?>
<Translations xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Translation Id="BroadcastAirdrop" Value="{0} called in airdrop!" />
</Translations>
```