'use client';

import { useContext, useState } from "react";
import { IoIosArrowDown, IoIosArrowForward } from "react-icons/io";
import { Input } from "../inputWithLabel";
import { AplicationContext } from "@/contexts/appContext";

export default function ResponseElementDropDown({ response } : { response: any }) {
    const [open, isOpen] = useState<boolean>(false);
    
    const colorStatus: any = {
      "200": {
        "background-color": "bg-green-400",
        "text-color": "text-green-700"
      },
      "400": {
        "background-color": "bg-red-400",
        "text-color": "text-red-700"
      },
      "401": {
        "background-color": "bg-yellow-400",
        "text-color": "text-yellow-700"
      }
    }

    const {
      getPaths,
      getRouters,
      formatResponses,
      getSchema,
      apiDatas
    } = useContext(AplicationContext);
    
    return (
      <div className={`p-4 ${colorStatus[response.key] != undefined ? colorStatus[response.key]["background-color"] : 'bg-blue-400'} rounded-lg w-full`} >
        <div className="flex justify-between items-center cursor-pointer" onClick={() => {
          isOpen(!open);
          
          if(document.getElementById(`response-code-${response.key}`)!.classList.contains('hidden')) {
            document.getElementById(`response-code-${response.key}`)!.classList.remove('hidden')
          } else {
            document.getElementById(`response-code-${response.key}`)!.classList.add('hidden')
          }
        }}>
          <p className={`${colorStatus[response.key] != undefined ? colorStatus[response.key]["text-color"] : 'text-blue-700'} pb-2`}>{response.key}</p>
          {open ? <IoIosArrowDown color="white" /> : <IoIosArrowForward size={15} color="white" />}
        </div>
        <div id={`response-code-${response.key}`} className=" bg-white rounded-lg p-5 hidden">
          <p className="text-sm/6 border-b-gray-400/[.2] border-b-[1px]"><span className="text-gray-400">RESPONSE SCHEMA</span>: <span className="font-[700]">{response.content != undefined ? Object.keys(response.content)[0] : <></>}</span></p>
          <div className="pt-7">
            <div className="flex justify-between">
              <div>
                <p className="text-sm/6 font-[700]">{"{"}</p>
                
                <div className="flex flex-col gap-2 ml-4">  
                  {
                    response.content != undefined ? 
                    Object.keys(getSchema(response.content[Object.keys(response.content)[0]].schema.$ref.split('/')[3]).properties).map((property: string, index: number) => {
                      const value = getSchema(response.content[Object.keys(response.content)[0]].schema.$ref.split('/')[3]).properties[property];
  
                      if(value.$ref != undefined) {
                        const type = getSchema(value.$ref.split('/')[3]).properties;
                        return (
                          <div key={index}>
                            <span className="text-sm/6 font-[700]">{property} : {"{"}</span>
                            
                            <div className="flex flex-col gap-2 ml-4"> 
                              {
                                Object.keys(type).map((keyType, index2) => {
                                  return (
                                    <div className="flex gap-2" key={index2}>
                                      <span className="text-sm/6 font-[700]">{keyType}</span>: <Input disabled={true} defaultValue={type[keyType].type} />
                                    </div>
                                  )
                                })
                              }
                            </div>
  
                            <p className="text-sm/6 font-[700]">{"}"}</p>
                          </div>
                        )
                      } else {
                        if(value.type == "object") {
                          return (
                            <div className="flex gap-2" key={index}>
                              <span className="text-sm/6 font-[700]">{property}</span>: <Input disabled={true} defaultValue={value.additionalProperties.type}  />
                            </div>
                          )
                        } else {
                          return (
                            <div className="flex gap-2" key={index}>
                              <span className="text-sm/6 font-[700]">{property}</span>: <Input disabled={true} defaultValue={value.type} />
                            </div>
                          )
                        }
                      }
                    })
                    : <></>
                  }
                </div>
                <p className="text-sm/6 font-[700]">{"}"} </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    )
  }