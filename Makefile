net = dotnet

publish:
	$(net) publish -r linux-x64 -p:PublishSingleFile=true -c Release --output ./out/publish

run:
	$(net) run

build:
	$(net) publish -r linux-x64 -p:PublishSingleFile=true -c Debug --output ./out/build