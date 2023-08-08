Move-Item -Path GameData/MinorPlanetSampling/MinorPlanetSampling.dll -Destination GameData/MinorPlanetSampling.dll
Remove-Item -Path GameData/MinorPlanetSampling/*.dll
Remove-Item -Path GameData/MinorPlanetSampling/*.pdb
Move-Item -Path GameData/MinorPlanetSampling.dll -Destination GameData/MinorPlanetSampling/MinorPlanetSampling.dll