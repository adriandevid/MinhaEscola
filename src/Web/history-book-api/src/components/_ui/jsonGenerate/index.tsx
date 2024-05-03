import { Input } from "../inputWithLabel";

export default function JsonGenerate({ loading, properties, modelChange, propertieFather }: { loading: boolean, properties: any, modelChange: any, propertieFather?: string }) {
    console.log(properties)
    return (
        <div>
            <p className="text-sm/6 font-[700]">{"{"}</p>
            <div className="flex flex-col gap-2 ml-4">
                {
                    Object.keys(properties).map(function (propertie, index) {
                        if(typeof(properties[propertie]) == "object" && properties[propertie] != undefined) {
                            return (
                                <div className="flex gap-2" key={index}>
                                    <span className="text-sm/6 font-[700]">{propertie}</span> : {JsonGenerate({ loading, properties: properties[propertie], modelChange, propertieFather: propertie })}
                                </div>
                            )
                        } else {
                            if(typeof(properties[propertie]) != "object" && propertie != undefined && propertie != null) {
                                return (
                                    <div className="flex gap-2" key={index}>
                                        <span className="text-sm/6 font-[700]">{propertie}</span>: <Input disabled={loading} defaultValue={properties[propertie]} propertie={propertie} fatherPropertieName={propertieFather} onChange={modelChange} />
                                    </div>
                                )
                            } else {
                                return (
                                    <div className="flex gap-2" key={index}>
                                        <span className="text-sm/6 font-[700]">{propertie}</span>: <Input disabled={loading} defaultValue={"example"} propertie={propertie} fatherPropertieName={propertieFather} onChange={modelChange} />
                                    </div>
                                )
                            }
                        }
                    })
                }
            </div>
            <p className="text-sm/6 font-[700]">{"}"} </p>
        </div>
    )
}