'use client';

import { FaConnectdevelop, FaLock } from "react-icons/fa";
import ResponseElementDropDown from "../../_ui/dropdownResponse";
import { Input } from "../../_ui/inputWithLabel";
import DescriptionRequest from "../../_ui/descriptionRequest";
import { useContext, useEffect, useState } from "react";
import { AxiosStatic } from "axios";
import axios from 'axios';
import { AplicationContext } from "@/contexts/appContext";
import { useSession } from "next-auth/react";
import JsonGenerate from "@/components/_ui/jsonGenerate";

export const requestTypeDefault: any = {
    post: async (request: any, instance: AxiosStatic, url: string) => await instance.post(url, request),
    put: async (request: any, instance: AxiosStatic, url: string) => await instance.put(url, request),
    delete: async (request: any, instance: AxiosStatic, url: string) => await instance.delete(url),
    get: async (request: any, instance: AxiosStatic, url: string) => await instance.get(url),
}

  
export function Router({ router, method, path } : { router: any, method: string, path: string }) {
    const {
      getPaths,
      getRouters,
      formatResponses,
      getSchema,
      apiDatas
    } = useContext(AplicationContext);

    const { data: session, status } : any = useSession();
    
    const infoMethod = router.routers.filter((reference: any) => reference.method == method)[0];
    console.log(infoMethod)
    //console.log(getSchema(infoMethod.content.requestBody.content["application/json"].schema.$ref.split('/')[3]))
    const responses = formatResponses(infoMethod.content.responses);
    
    const [loading, isLoading] = useState<boolean>(false);
  
    const [prepareRequest, setPrepareRequest] = useState<any>();
    const [paramsMap, setParamMap] = useState<any>();
  
    const [responseSubmit, setResponseSubmit] = useState();
    const [expandToken, isExpandToken] = useState<boolean>(false);

    const submitRequest = async () => {
      isLoading(true);
  
      const request = requestTypeDefault[method];
      var urlPush = router.key;
      
      if(paramsMap != undefined) {
        Object.keys(paramsMap).forEach((item) => {
          urlPush = urlPush.replaceAll(`{${item}}`, paramsMap[item]);
        })
      }
  
      if(session != undefined) {
        axios.defaults.headers.common.Authorization = `Bearer ${session.user.access_token}`;
      }

      request(prepareRequest, axios, `${apiDatas.servers[0].url}${urlPush}`).then(function (response: any) {
        isLoading(false);
        setResponseSubmit(response.data);
      }).catch(function (response: any) {
        isLoading(false);
        setResponseSubmit(response);
      });
  
    }
  
    useEffect(function () {
      setParamMap(undefined);
      setResponseSubmit(undefined);
  
      var prepareRequestBase: any = undefined;
  
      if(infoMethod.content.requestBody != undefined) {
        if(getSchema(infoMethod.content.requestBody.content["application/json"].schema.$ref.split('/')[3]).properties != undefined) {
          prepareRequestBase = getSchema(infoMethod.content.requestBody.content["application/json"].schema.$ref.split('/')[3]).properties;
        
          Object.keys(getSchema(infoMethod.content.requestBody.content["application/json"].schema.$ref.split('/')[3]).properties).filter((propertie) => {
            prepareRequestBase[propertie] = "example";
          })
    
          setPrepareRequest({
            ...prepareRequestBase
          })
        } else if (getSchema(infoMethod.content.requestBody.content["application/json"].schema.$ref.split('/')[3]).allOf != undefined) {
          prepareRequestBase = getSchema(infoMethod.content.requestBody.content["application/json"].schema.$ref.split('/')[3]).example;
        
          Object.keys(getSchema(infoMethod.content.requestBody.content["application/json"].schema.$ref.split('/')[3]).example).filter((propertie) => {
            prepareRequestBase[propertie] = prepareRequestBase[propertie];
          })
    
          setPrepareRequest({
            ...prepareRequestBase
          })
        }
      }
    }, [router, method, path])


    const schema = infoMethod.content.requestBody != undefined ? getSchema(infoMethod.content.requestBody.content["application/json"].schema.$ref.split('/')[3]) : undefined;
  
    useEffect(function () {
      console.log(prepareRequest)
    }, [prepareRequest])
    return (
      <div className="p-10 w-full overscroll-x-none overflow-scroll overflow-x-hidden">
          <div className="pb-4">
            <p className="text-sm/6">{path} - <span className="font-[700]">{router.key}</span></p>
          </div>
          <div className="flex flex-col">
            <div><div className="spin-rotate"><FaConnectdevelop color="green" size={50} /></div> </div>
            <p className="font-[700] text-[2rem]">{router.key}</p>
            <span className="text-gray-400 text-[1rem]">{infoMethod.content.description}</span>
            <p className="font-semibold text-sm/6 pt-4">Operation ID: <span className="text-gray-400 text-sm/6">{infoMethod.content.operationId}</span></p>
            <div>
              <a href="#" className="text-sm/6 text-blue-400">Download Documentation in OpenApi Pattern</a>
            </div>
            <div>
              <a href={process.env.NEXT_PUBLIC_URL_GITHUB?.replace("{path}", path.toLowerCase()).replace("{operationId}", infoMethod.content.operationId)} className="text-sm/6 text-blue-400">Download report of load test with k6.</a>
            </div>
          </div>
          <div className="flex flex-col gap-2 pt-5 pb-5">
            <div className="pt-5 text-sm/6">
              <div className="flex gap-2 items-center font-[700]"><FaLock /><p>HTTP Authorization Scheme: <span className="font-[500] italic text-red-400">Bearer</span></p></div>
              <div className="bg-gray-400/[.2] rounded-lg p-4 w-[80%] mt-2"><span className="italic">Bearer</span> <p className="break-words text-sm/6 normal">{session.user.access_token.length > 400 && expandToken == false ? session.user.access_token.substring(0, 400) + "..." : session.user.access_token}</p><p className="text-blue-400 cursor-pointer w-max" onClick={() => { isExpandToken(!expandToken) }}>{expandToken ? "- Ver menos" : "+ Ver mais"}</p></div>
            </div>
          </div>
          <div className="border-t-[1px] border-t-gray-400/[.2] pt-10">
            <p className="font-bold pb-4">Resquest</p>
            <div className="border-t-[1px] border-t-gray-400/[.2] bg-[#263238] rounded-lg">
              <div className="m-5">
                <DescriptionRequest method={method} router={router} />
                <div className="bg-[#11171a] p-5 rounded-lg rounded-lg mt-5">
                  <fieldset className="bg-[#263238] flex flex-col justify-start rounded-lg p-2">
                    <legend className="text-white font-semibold text-sm/6 m-0 p-0">Content Type</legend>
                    <p className="text-white pb-4 text-sm/6">application/json</p>
                  </fieldset>
                  <button className={`${loading? 'text-gray-400/[.5]': 'text-[#11171a]'} bg-white p-2 rounded-lg text-sm/6 w-[9rem] font-semibold mt-4 cursor-pointer`} onClick={() => { submitRequest() }} disabled={loading}>Send Request</button>
                    
                  <div className="text-white">
                    <div className="p-5">
                      <div className="flex flex-col">
                        <p className="font-semibold pt-2 text-[15px] border-b-[3px] border-b-blue-400 mb-4 w-[10rem]">REQUEST BODY</p>
                        {
                          infoMethod.content.requestBody != undefined ?
                          <JsonGenerate properties={schema.properties != undefined ? schema.properties : schema.allOf != undefined ? schema.example : {}} loading={loading} modelChange={(value: any, propertie: string, fatherPropertieName?: string | undefined) => {
                            if(fatherPropertieName != undefined){
                              if(prepareRequest == undefined) {
                                var prepareRequestBase: any = {}
                                prepareRequestBase[fatherPropertieName][propertie] = value;
                                
                                setPrepareRequest({
                                  ...prepareRequestBase
                                })
                              } else {
                                prepareRequest[fatherPropertieName][propertie] = value;
                                setPrepareRequest({
                                  ...prepareRequest
                                })  
                              }
                            } else {
                              if(prepareRequest == undefined) {
                                var prepareRequestBase: any = {}
                                prepareRequestBase[propertie] = value;
                                
                                setPrepareRequest({
                                  ...prepareRequestBase
                                })
                              } else {
                                prepareRequest[propertie] = value;
                                setPrepareRequest({
                                  ...prepareRequest
                                })  
                              }
                            }
                          }}></JsonGenerate>
                          : <p className="text-sm/6">No Request Body</p>
                        }
                        <p className="font-semibold pt-5 text-[15px] border-b-[3px] border-b-blue-400 mb-4 w-[10rem]">PARAMS</p>
                        {
                          infoMethod.content.parameters != undefined ?
                            infoMethod.content.parameters.map((params: any, index: number) =>{
                              return (
                                <div className="flex gap-2 pt-2 items-center" key={index}>
                                  <span className="text-sm/6 font-[700]">{params.name}</span>: <input className="rounded-[5px] p-1 w-[5rem] text-black focus:outline-none text-sm/6" type={params.schema.type == "integer" ? "number" : "text"} disabled={loading} name={params.name} onChange={(e: any) => {
                                    if(paramsMap == undefined) {
                                      var paramsContainer: any = {};
                                      paramsContainer[params.name] = e.target.value;
                                      setParamMap({
                                        ...paramsContainer
                                      }) 
  
                                      return;
                                    } else{
                                      paramsMap[params.name] = e.target.value;
                                      setParamMap({
                                        ...paramsMap
                                      })
                                    }
                                  }} />
                                </div>
                              )
                            }) : <p className="text-sm/6">No Request Params</p>
                          }
                      </div>
                    </div>
                    <div className="text-sm/6 bg-gray-400/[.2] p-4 rounded-lg mt-10 mb-5">
                      <p className="font-bold">Response Request: </p>
                      <div className="break-words">
                        {
                          loading ?
                          <div className="flex flex-col justify-center items-center">
                            <div className="relative">
                              <div className="spin-rotate absolute"><FaConnectdevelop color="green" size={100} /></div> 
                              <div className="spin-rotate-return asbolute"><FaConnectdevelop color="green" size={100} /></div>
                            </div>
                            <p className="mt-2 font-bold">Loading...</p>
                          </div> : JSON.stringify(responseSubmit)
                        }
                      </div>
                    </div>
                  </div>
                </div>
                
                <div className="pb-10"></div>
              </div>
            </div>
          </div>
          <div className="border-t-[1px] border-t-gray-400/[.2] pt-10 flex flex-col gap-2">
            <p className="font-bold pb-4">Responses</p>
            {
              responses.map((response: any, index: number) => {
                return (<ResponseElementDropDown response={response} key={index}></ResponseElementDropDown>)
              })
            }
          </div>
      </div>
    )
}