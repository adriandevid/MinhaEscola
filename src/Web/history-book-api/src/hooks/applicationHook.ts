import axios from "axios";
import { useSession } from "next-auth/react";
import { useEffect, useState } from "react";

export interface ApplicationHookProps {
    apiDatas: any,
    getPaths: () => any,
    getRouters: (path: string) => any,
    formatResponses: (responses: any) => any,
    getSchema: (name: string) => any
}

export default function useApplicationHook() {
    const [apiDatas, setDatas] = useState<any>();
   
    
    useEffect(function () {
        axios.get(`${process.env.NEXT_PUBLIC_URL_SWAGGER}`).then(function (response) {
            setDatas(response.data)
        })
    }, [])
    
    function getPaths() {
        if(apiDatas != undefined) {
            const primaryList = Object.keys(apiDatas.paths).map((item: string) => {
                var paths: any = apiDatas.paths;
                return paths[item][Object.keys(paths[item])[0]].tags[0];
            })
          
            const unic: any[] = [];
          
            primaryList.forEach(element => {
                if(!unic.includes(element)) {
                  unic.push(element)
                }
            })
            
      
            return unic;
        }

        return [];
    }
      
    function getRouters(path: string) 
    {
        if(apiDatas != undefined) {
            const paths: any = apiDatas.paths;
            const pathsSourceds = Object.keys(apiDatas.paths).filter((item) => paths[item][Object.keys(paths[item])[0]].tags[0] == path);
            return pathsSourceds.map((item: string) => {
                return {
                key: item,
                routers: Object.keys(paths[item]).map((method) => {
                    return {
                    method: method,
                    content: paths[item][method]
                    }
                })
                }
            });
        }

        return [];
    }
      
    function formatResponses(responses: any) {
        return Object.keys(responses).map((response) => {
          return {
            key: response,
            content: responses[response].content
          }
        })
    }
      
      
    function getSchema(name: string) {
        console.log(apiDatas)
        var schemas: any = apiDatas.components.schemas;
        return schemas[name];
    }


    return {
        apiDatas,
        getPaths,
        getRouters,
        formatResponses,
        getSchema
    }
}